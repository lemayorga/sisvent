import React from 'react'; 
import MainMenu from './menu/MainMenu';

export default function SideBar(){

    return(
		<div className="sidebar sidebar-style-2">			
			<div className="sidebar-wrapper scrollbar scrollbar-inner">
				<div className="sidebar-content">
					<div className="user">
						<div className="avatar-sm float-left mr-2">
							<img src="./assets/img/profile.jpg" alt="..." className="avatar-img rounded-circle" />
						</div>
						<div className="info">
							<a data-toggle="collapse" href="#collapseExample" aria-expanded="true">
								<span>
									Hizrian
									<span className="user-level">Administrator</span>
									<span className="caret"></span>
								</span>
							</a>
							<div className="clearfix"></div>

							<div className="collapse in" id="collapseExample">
								<ul className="nav">
									<li>
										<a href="#profile">
											<span className="link-collapse">My Profile</span>
										</a>
									</li>
									<li>
										<a href="#edit">
											<span className="link-collapse">Edit Profile</span>
										</a>
									</li>
									<li>
										<a href="#settings">
											<span className="link-collapse">Settings</span>
										</a>
									</li>
								</ul>
							</div>
						</div>
					</div>
					<MainMenu />
				</div>
			</div>
		</div>

    );
}