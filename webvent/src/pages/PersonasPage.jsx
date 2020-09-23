import React,{ useEffect , useState} from 'react';
import { useSelector, useDispatch  } from 'react-redux';
import  
{ 
  getAllPersonas, 
  addPersona,
  getPersona ,
  updatePersona,
  dispathNewPersona,  
  deletePersona,
} from '../redux/actions/personasAction';
import 
{ 
  Button, 
  Modal, 
  Form, 
  Popconfirm, 
  message
} from 'antd';
import { EditOutlined, DeleteOutlined } from '@ant-design/icons';
import Table_ from '../utils/Table_';
import PersonaForm from '../components/personas/PersonaForm';

function PersonasPage (){

  const [showModal, setShowModal] = useState(false);
  const listadoPersonas = useSelector(state => state.personasStore.personas);
  const persona = useSelector(state => state.personasStore.persona);
  const [form ]  = Form.useForm();
  const dispatch = useDispatch();

  useEffect(() =>{
    dispatch(getAllPersonas())
  },[dispatch])



  const hanldeCloseModal = () => {
    setShowModal(false)    
  };


 const handleOk = e => {  
  form
    .validateFields()
    .then((values) => {
      console.log(values);
      console.log(!values.personaId);

      const nuevaPersona = addPersona(values, 
        (response) => {         
          Modal.success({  content: 'Datos guardados exitosamente' });
          form.resetFields();
          setShowModal(false);
        }, (error) => {
              console.log(error)
              Modal.error({ title: 'Ocurrio un error',   content: error });
        });
        
        const modificarPersona = updatePersona(values, 
          (response) => {         
            Modal.success({  content: 'Datos guardados exitosamente' });
            form.resetFields();
            setShowModal(false);
          }, (error) => {
                console.log(error)
                Modal.error({ title: 'Ocurrio un error',   content: error });
          });

      if(!values.personaId)
        dispatch(nuevaPersona)
      else
        dispatch(modificarPersona)
    })
    .catch((info) => {
      console.log('Validate Failed:', info);
    });
};

const handelRowEdit = key_row => {
 dispatch(getPersona(key_row,
  response =>  setShowModal(true) ,
  error => {
    console.log(error)
    Modal.error({
      title: 'Ocurrio un error',
      content: error,
    });
  }));
}

 
const handleDelete =  key_row => {
   dispatch(deletePersona(key_row,
    response => {
      message.success('Click on Yes');
    },
    error =>   Modal.error({ title: 'Ocurrio un error',   content: error })
  ))
}


const cancel = (e)  => {
  console.log(e);
  message.error('Click on No');
}



const columns = [
  {
    title: 'Codigo',
    dataIndex: 'personaId',
    width: '5%'
  },
  {
    title: 'nombres',
    dataIndex: 'nombres',
    width: '20%'
  },
  {
    title: 'apellidos',
    dataIndex: 'apellidos',
    width: '20%'
  },
  {
    title: 'sexo',
    dataIndex: 'sexo',
    width: '20%'
  },
  {
    title: 'Acción',
    dataIndex: 'personaId',
    width: '20%',
    render: text => (
      <>
        <Button  type="link"
                 icon={<EditOutlined />}
                 onClick={() => handelRowEdit(text) }
                >Editar</Button> 
      <Popconfirm
        title="¿Esta seguro de eliminar el registro?"
        icon={ <DeleteOutlined /> }
        onConfirm={(e) => handleDelete(text)}
        onCancel={cancel}
        okText="Si"
        cancelText="No"
      >
        <Button  type="link" danger icon={ <DeleteOutlined /> } >Eliminar</Button> 
      </Popconfirm>

      </>
    )
  },
];
  return(
    <>
      <div className="row">
        <div className="col-md-12">
          <div className="card">
            <div className="card-header">
              <div className="card-title">
                <div className="row">
                  <div className="col-md-6">Listado de Personas</div>
                  <div className="col-md-6">
                    <Button type="primary" style={{ float:"right"}}
                        onClick={() => {
                          dispatch(dispathNewPersona())
                          setShowModal(true)
                        } }
                      >
                        Agregar persona
                      </Button>
                  </div>
                </div>
              </div>
            </div>
            <div className="card-body">
              <Table_ columns={columns} 
                      data={listadoPersonas}
                      rowKey={"personaId"} 
                    />
            </div>
          </div>    
        </div>
      </div>
    
        <Modal
            title="Registro de persona"
            visible={showModal}
            centered={true}
            onOk={ (e) => handleOk(e) }
            onCancel={() => hanldeCloseModal()}
            okText="Guardar"
            cancelText="Cancelar"
          >
          <PersonaForm form={form} model_persona={persona} />
        </Modal> 

    </>
  );
}

export default PersonasPage;


