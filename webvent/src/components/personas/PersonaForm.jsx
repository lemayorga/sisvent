import React, { useEffect } from 'react';
import { PropTypes } from 'prop-types';
import { Form, Input, InputNumber, Button } from 'antd';

const validateMessages = {
  required: 'Campo ${label} es requerido!',
  types: {
    email: '${label} is not validate email!',
    number: '${label} is not a validate number!',
  },
  number: {
    range: '${label} must be between ${min} and ${max}',
  },
};

const onFinish = (values) => {
  console.log(values);
};

const formItemLayout = {
  labelCol: {
    xs: {
      span: 12,
    },
    sm: {
      span: 4,
    },
  },
  wrapperCol: {
    xs: {
      span: 24,
    },
    sm: {
      span: 16,
    },
  },
};

const PersonaForm = ({ form, model_persona }) => {
  
   console.log(model_persona) 
  
   const loadProfile = () => form.setFieldsValue(model_persona)

  useEffect(() => {
		loadProfile();
	}, [model_persona]);

    return (

      <Form {...formItemLayout} 
          name="nest-messages" 
          onFinish={onFinish} 
          validateMessages={validateMessages}
          form={form}
      >
      <Form.Item name={['personaId']} 
                  label="personaId" noStyle
      >
        <Input  type="hidden"  />
      </Form.Item>
      <Form.Item name={['tipoPersona']} 
                  label="tipoPersona" noStyle
      >
        <Input  type="hidden" value="N"  />
      </Form.Item>
      <Form.Item name={['nombres']}
                 label="Nombres"
                 rules={[  { required: true, },  ]}
      >
        <Input />
      </Form.Item>
      <Form.Item name={['apellidos']}
                 label="Apellidos"
                 rules={[  { required: true, },  ]}
      >
        <Input />
      </Form.Item>
    </Form>

  );
}

export default PersonaForm; 